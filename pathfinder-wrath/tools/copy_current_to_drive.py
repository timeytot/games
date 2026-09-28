"""Copy the current text snapshot and one save file into Google Drive.

The Drive root comes from DriveFS root_preference_sqlite.db. If that mount
does not contain exactly one user folder, this script prints the candidates
and exits without writing.
"""
import os
import shutil
import sqlite3
import sys

SKIP = {".shortcut-targets-by-id", "$RECYCLE.BIN", ".Encrypted"}
NAMES = (
    "Current_Save.json",
    "Party_Current.json",
    "Kestoglyr_Current.json",
    "Horse_Current.json",
    "Current_Report.md",
)


def drive_user_folder():
    db = os.path.expandvars(r"%LOCALAPPDATA%\Google\DriveFS\root_preference_sqlite.db")
    if not os.path.exists(db):
        print("DRIVE_SKIP database missing")
        return None
    uri = "file:" + db.replace("\\", "/") + "?mode=ro"
    con = sqlite3.connect(uri, uri=True)
    row = con.execute(
        "select last_mount_point from media where name=?",
        ("Google Drive",),
    ).fetchone()
    if not row or not row[0] or not os.path.isdir(row[0]):
        print("DRIVE_SKIP mount missing", row)
        return None
    children = []
    for name in os.listdir(row[0]):
        path = os.path.join(row[0], name)
        if os.path.isdir(path) and name not in SKIP and not name.startswith("."):
            children.append(path)
    if len(children) != 1:
        print("DRIVE_SKIP candidates:")
        for child in children:
            print(child)
        return None
    return children[0]


def main():
    if len(sys.argv) != 3:
        print("usage: copy_current_to_drive.py <current-dir> <save-copy>")
        return 1
    current, save_copy = sys.argv[1], sys.argv[2]
    folder = drive_user_folder()
    if not folder:
        return 0
    dest = os.path.join(folder, "games", "pathfinder-wrath", "current")
    os.makedirs(dest, exist_ok=True)
    shutil.copy2(save_copy, os.path.join(dest, "Latest_Save.zks"))
    for name in NAMES:
        shutil.copy2(os.path.join(current, name), os.path.join(dest, name))
    print("DRIVE_OK", dest)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
