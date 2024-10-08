GET http://localhost:5011/games
HTTP 200

GET http://localhost:5011/games/1
HTTP 200

POST http://localhost:5011/games
{
	"name": "Nama",
	"genre": "Genre",
	"price": 99.99,
	"releaseDate": "2011-11-18"
}
HTTP 201

PUT http://localhost:5011/games/1
{
	"name": "Nama",
	"genre": "Genre",
	"price": 99.99,
	"releaseDate": "2011-11-18"
}
HTTP 204

DELETE http://localhost:5011/games/1
{
	"name": "Nama",
	"genre": "Genre",
	"price": 99.99,
	"releaseDate": "2011-11-18"
}
HTTP 204

GET http://localhost:5011/games/66
HTTP 404
