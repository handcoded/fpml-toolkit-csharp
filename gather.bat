RMDIR /Q /S dist
MKDIR dist
MKDIR dist\files-core
MKDIR dist\files-fpml
MKDIR dist\doc
MKDIR dist\manual
XCOPY /S files-core dist\files-core
XCOPY /S files-fpml dist\files-fpml
XCOPY /S doc dist\doc
XCOPY /S manual dist\manual
COPY Validate\bin\Release\*.dll dist
COPY Validate\bin\Release\*.exe dist
COPY misc-fpml\*.* dist
COPY license.txt dist
COPY readme.htm dist