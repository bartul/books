mongoimport --db catalog --collection books --drop --file ./data/catalog.books.json
mongo catalog --eval 'db.books.createIndex({ ISBN: 1 })'
mongo catalog --eval 'db.books.createIndex({ BookTitle: "text" }, { name: "BookTextIndex"})'
