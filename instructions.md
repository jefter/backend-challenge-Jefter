A aplica��o est� configurada na URL  http://localhost:49290/


SWAGGER:

http://localhost:49290/swagger/index.html

A vers�o utilizada do .NET CORE � 5.0 na API e .NET Stantard 2.1 nas bibliotecas de classes;

O arquivo de banco de dados est� na raiz do projeto desafio.api com o nome: desafioDB

O arquivo de bando de dados utilzado nos testes unit�rio est� localizado na pasta desafio.serviceTests\bin\Debug\netcoreapp3.1\


Chamadas dos endpoint Pedido.

+++++++++++++++++++++++++++++++++++++++++


GET

http://localhost:49290/api/Pedido

Retorna todas os pedidos cadastrados.

Chamada exemplo:
curl -X GET "http://localhost:49290/api/Pedido" -H  "accept: text/plain"

+++++++++++++++++++++++++++++++++++++++++

POST


Cria um novo pedido 

http://localhost:49290/api/Pedido


BODY:

{
  "pedido":"123456",
  "itens": [
  {
    "descricao": "Item A",
    "precoUnitario": 10,
    "qtd": 1
  },
  {
    "descricao": "Item B",
    "precoUnitario": 5,
    "qtd": 2
  }
  ]
}


Chamada exemplo:

curl -X POST "http://localhost:49290/api/Pedido" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"pedido\":\"99999\",\"itens\":[{\"descricao\":\"Descircao do item A\",\"precoUnitario\":10,\"qtd\":1},{\"descricao\":\"Descricao do item B\",\"precoUnitario\":5,\"qtd\":2}]}"

Valida��es existentes:

O c�digo do pedido n�o poder ser vazio

A quantidade do tem que ser maior que zero

A descri��o do item � obrigat�ria

O pre�o unit�rio tem que ser maior que zero

O c�digo do pedido � �nico.

+++++++++++++++++++++++++++++++++++++++++

PUT

Atualiza o pre�o unit�rio do item e a quantidade

http://localhost:49290/api/Pedido

Chamada exemplo:

curl -X PUT "http://localhost:49290/api/Pedido" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"itens\":[{\"qtd\":11,\"descricao\":\"Item A\",\"precoUnitario\":10,\"id\":13},{\"qtd\":22,\"descricao\":\"Item B\",\"precoUnitario\":5,\"id\":14}],\"pedido\":\"998877\",\"id\":7}"


BODY:

{
  "itens": [
        {
          "qtd": 11,
          "descricao": "Item A",
          "precoUnitario": 10,
          "id": 13
        },
        {
          "qtd": 22,
          "descricao": "Item B",
          "precoUnitario": 5,
          "id": 14
        }
      ],
      "pedido": "998877",
      "id": 7
}



+++++++++++++++++++++++++++++++++++++++++

DELETE 

/ Id

Deleta um pedido por Id

http://localhost:49290/api/Pedido/Id

Chamada exemplo:

curl -X DELETE "http://localhost:49290/api/Pedido/8" -H  "accept: */*"



+++++++++++++++++++++++++++++++++++++++++

GET - 

Obtem um pedido pelo c�digo


http://localhost:49290/api/Pedido/123456

Chamado de exemplo:

curl -X GET "http://localhost:49290/api/Pedido/123456" -H  "accept: text/plain"


+++++++++++++++++++++++++++++++++++++++++

Chamadas dos endpoint STATUS.


POST

Retorna o status do pedido.

http://localhost:49290/Status

BODY:

{
  "status":"APROVADO",
  "itensAprovados": 3,
  "valorAprovado": 20,
  "pedido":"123456"
}

Chamado exemplo 

curl -X POST "http://localhost:49290/Status" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"status\":\"APROVADO\",\"itensAprovados\":3,\"valorAprovado\":20,\"pedido\":\"123456\"}"


+++++++++++++++++++++++++++++++++++++++++++++++

O projeto desafio.ServiceTest cont�m os testes unit�rios das mudan�as de status
