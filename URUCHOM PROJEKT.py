import os
from subprocess import Popen

UNITYDIR = r"C:\Program Files\Unity"
ARGS = ["-projectPath", "."]

files = os.listdir(UNITYDIR)
selection = 0
print("Wybierz wersje:")
print("\n".join("%d: %s" % (i + 1, j) for i, j in enumerate(files)))

while selection not in range(1, len(files)):
    try:
        selection = int(input("? "))
    except ValueError:
        pass
    
editor = "%s\\%s\\Editor\\unity.exe" % (UNITYDIR, files[selection-1])

r = os.system("git pull")
if r != 0:
    print("Błąd w wykonywaniu 'git pull'!")
    input("Naciśnij enter, żeby kontynuować...")
else:
    Popen([editor] + ARGS)
