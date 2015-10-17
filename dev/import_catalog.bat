C:\mongodb\bin\mongoimport --db catalog --collection books --drop --file ./data/catalog.books.json

C:\mongodb\bin\mongo catalog --eval "db.books.createIndex({ ISBN: 1 })"

C:\mongodb\bin\mongo catalog --eval "db.books.createIndex({ BookTitle: 'text' }, { name: 'BookTextIndex'})"
