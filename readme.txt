GTFTO parser

Very simple text parser. 
Windows command line. Net 4.0.
Born in fighting with grep, awk, xindel, * and poorly formatted html-files.
GTFTO means Get That Freakin Text Out. That is what it does.
Takes all starting with "fromstring" (first occurence) to "tostring" (first occurence), then print all between to console as one big string.

Usage:
gtfto_parser "filename" "fromstring" "tostring"
Save to file:
gtfto_parser "filename" "fromstring" "tostring" >filename.txt

Do not forget mirroring!
Symbols & | > < ^ must have forestanding ^
Example: "^<div^>", not "<div>"
Inner double quotes must have forestanding \
Example: "align=\"right\"", not "align="right""

Exit codes:
0 - found
1 - not found
2 - missing parameters

Changelog:
0.1
Initial release.  Works.