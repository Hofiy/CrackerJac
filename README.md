# CrackerJac
MD5 Dictionary Cracking Software in C#

CrackerJac works by brute forcing either plain
unsalted MD5 hashes or MyBB-Style Hash:Salt.

Example of plain MD5 Hash cracking:
CrackerJac.exe dictionary.txt hashes.txt -u

This will start CrackerJac.exe with the argument
of the dictionary, which should look like:
word
anotherword
athirdword

It will then take in the hash file, which should look like:
person1 hash
person2 hash
person3 hash

Then the -u option tells it to do unsalted hashes.

To crack MyBB style hashes the hashes.txt file should look like:
person1 hash:salt
person2 hash:salt
person3 hash:salt

And to run CrackerJac to crack MyBB passwords run it like:
CrackerJac.exe dictionary.txt hashes.txt -s


Special thanks to SplittyDev for letting me borrow code for
the salt generating in Salting.cs.
