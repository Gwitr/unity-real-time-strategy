import os
import sys
import shlex

def cmd(c):
    print(c)
    r = os.system(c)
    if r != 0:
        print("error: '%s' returned code %d" % (c, r))
        sys.exit(1)

commit_msg = input("Wiadomość: ")
cmd("git add .")
cmd("git commit -am \"%s\"" % (commit_msg.replace("\"", "\\\"")))
cmd("git push")
input("Naciśnij Enter, aby kontynuować . . .")
