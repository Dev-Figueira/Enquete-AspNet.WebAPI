# Enquete-AspNet.WebAPI

## 💻 Project
**Asp.net-Wep-API** API RESTful para a utilização de uma enquete.

## :rocket: Tecnologias
Este projeto utiliza as seguintes Tecnologias:

- [Asp.net core]
- [C#]
- [entityFramework]
- [SqlServer]
- [AutoMapper]
- [FluentValidations]

<h2>Endpoints</h2>

<h3>[Get] /poll/:id </h3>
<pre>Retonar os dados de uma enquete e incrementa "Views". </pre>

![Get](https://user-images.githubusercontent.com/8441327/89214013-67b8cc00-d59c-11ea-8bdf-faa689690182.jpg)

<h3>[Post] /poll </h3>
<pre>Cria uma nova enquete</pre>

![Post](https://user-images.githubusercontent.com/8441327/89214043-74d5bb00-d59c-11ea-98ac-9800c18f0352.jpg)

<h3>[Post] /poll/:id/vote </h3>
<pre>Registra um novo voto para uma opção.</pre>

![Vote](https://user-images.githubusercontent.com/8441327/89214041-743d2480-d59c-11ea-83c4-826a61fe7258.jpg)

<h3>[Get] /poll/:id/stats </h3>
<pre>Retornar estatísticas sobre a enquete.</pre>

![Stats](https://user-images.githubusercontent.com/8441327/89214044-74d5bb00-d59c-11ea-95b6-722983cdfef6.jpg)
