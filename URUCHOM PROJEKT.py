import os
import sys
from subprocess import Popen, PIPE

UNITYDIR = r"C:\Program Files\Unity"
ARGS = ["-projectPath", "."]

p = Popen(["git", "status"], stdout=PIPE)
text = p.communicate()[0]
if b"working tree clean" not in text:
    d = input("WARNING: Projekt ma zmiany, które nie są na serwerze! Kontynuować? [T/N] ")
    if d.lower() != "y":
        print("Anulowano.")
        input("Naciśnij enter, żeby kontynuować...")
        sys.exit(0)

files = os.listdir(UNITYDIR)
if "2019.3.2f1" not in files:
    print("ERROR: Wersja Unity '2019.3.2f1' nie istnieje! Uruchom Unity Hub i ją zainstaluj.")
    input("Naciśnij enter, żeby kontynuować...")
    sys.exit(0)

"""
selection = 0
print("Wybierz wersje:")
print("\n".join("%d: %s" % (i + 1, j) for i, j in enumerate(files)))

while selection not in range(1, len(files)):
    try:
        selection = int(input("? "))
    except ValueError:
        pass"""
    
# editor = "%s\\%s\\Editor\\unity.exe" % (UNITYDIR, files[selection-1])

editor = "%s\\%s\\Editor\\unity.exe" % (UNITYDIR, "2019.3.2f1")

r = os.system("git pull")
if r != 0:
    print("Błąd w wykonywaniu 'git pull'!")
    input("Naciśnij enter, żeby kontynuować...")
else:
    Popen([editor] + ARGS)
