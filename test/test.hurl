GET http://localhost:5000/pizzas
HTTP 200

POST http://localhost:5000/pizzas
{
	"id": 1,
	"name": "String"
}
HTTP 201

GET http://localhost:5000/pizzas/1
HTTP 200

PUT http://localhost:5000/pizzas/2
{
	"id": 1,
	"name": "String"
}
HTTP 404

PUT http://localhost:5000/pizzas/1
{
	"id": 1,
	"name": "String2"
}
HTTP 204

DELETE http://localhost:5000/pizzas/1
HTTP 204

