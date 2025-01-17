# Apuntes MongoDB

Apuntes de codigo de MongoDB para que no se pierdan en el olvido (paso de volverme a mirar lo videos)

> NOTA: </br>
> Esto no esta perfecto ni de lejos, sirve solo para mirar por encima


![verdad](https://www.emezeta.com/weblog/meme-la-cosa/cosa-no-pinta-nada-bien.jpg)
## Estructura de los documentos
`_id` es obligatorio, pero si creas uno sin te lo crea automaticamente

Sintaxis:
```json
{
    "key": value,
    "key": value,
    "key" : value
}
```
Ejemplo:
```json
{
    "_id": 1,
    "name": "AC3 Phone",
    "colors" : ["black", "silver"],
    "price" : 200,
    "available" : true
}
```
</br>

## Insertar y buscar documentos
### Insertar **UN SOLO** documento
Usa `insertOne()` para insertar un solo documento en una colección.
<br>
<br>
Ejemplo:
```js
db.grades.insertOne({
  student_id: 654321,
  products: [
    {
      type: "exam",
      score: 90,
    },
    {
      type: "homework",
      score: 59,
    },
    {
      type: "quiz",
      score: 75,
    },
    {
      type: "homework",
      score: 88,
    },
  ],
  class_id: 550,
})
```
</br>

### Insertar **MÚLTIPLES** documentos
Usa `insertMany()` para insertar múltiples documentos en una colección.

Ejemplo:
```js
db.grades.insertMany([
  {
    student_id: 546789,
    products: [
      {
        type: "quiz",
        score: 50,
      },
      {
        type: "homework",
        score: 70,
      },
      {
        type: "quiz",
        score: 66,
      },
      {
        type: "exam",
        score: 70,
      },
    ],
    class_id: 551,
  },
  {
    student_id: 777777,
    products: [
      {
        type: "exam",
        score: 83,
      },
      {
        type: "quiz",
        score: 59,
      },
      {
        type: "quiz",
        score: 72,
      },
      {
        type: "quiz",
        score: 67,
      },
    ],
    class_id: 550,
  },
  {
    student_id: 223344,
    products: [
      {
        type: "exam",
        score: 45,
      },
      {
        type: "homework",
        score: 39,
      },
      {
        type: "quiz",
        score: 40,
      },
      {
        type: "homework",
        score: 88,
      },
    ],
    class_id: 551,
  },
])
```
</br>

### Buscar documentos
Puedes buscar usando `find()` si sabes el `_id` de un documento.

Ejemplo:
```js
db.zips.find({ _id: ObjectId("5c8eccc1caa187d17ca6ed16") })
```

### Buscar documentos usando `$in`
Usa `$in` para poder buscar desde otro parámentro.

Ejemplo:
```js
db.zips.find({ city: { $in: ["PHOENIX", "CHICAGO"] } })
```
</br>

### Buscar documentos usando operadores de comparación

Puedes usar los siguientes operadores para buscar:

#### `$gt`:
Usa este para buscar documentos con un valor más grande que el valor dado para el parámetro.
```js
db.sales.find({ "items.price": { $gt: 50}})
```
#### `$lt`:
Usa este para buscar documentos con un valor más pequeño que el valor dado para el parámetro.
```js
db.sales.find({ "items.price": { $lt: 50}})
```

#### `$lte`:
Usa este para buscar documentos con un valor más pequeño o igual que el valor dado para el parámetro.
```js
db.sales.find({ "customer.age": { $lte: 65}})
```

#### `$gte`:
Usa este para buscar documentos con un valor más grande o igual que el valor dado para el parámetro.
```js
db.sales.find({ "customer.age": { $gte: 65}})
```

### Usar una Query en elementos de una Array
#### Buscar documentos con un Array que contiene un valor
Se puede poner directamente sin [ ] para que devuelva todos los documentos que contengan el valor

Ejemplo:
```js
db.accounts.find({ products: "InvestmentFund"})
```
</br>

#### Buscar documentos usando `$elemMatch`
Usa `$elemMatch` para buscar todos los documentos que contengan un subdocumento específico.

Ejemplo:
```js
db.sales.find({
  items: {
    $elemMatch: { name: "laptop", price: { $gt: 800 }, quantity: { $gte: 1 } },
  },
})
```
</br>

### Buscar documentos usando operadores lógicos
#### `$and`
Usa este para buscar un documento con múltiples expresiones.

Ejemplo:
```js
db.routes.find({ "airline.name": "Southwest Airlines", stops: { $gte: 1 } })
```

#### `$or`
Usa este para buscar un documento que concuerda con **UNA** de las dos expresiones.

Ejemplo:
```js
db.routes.find({
  $or: [{ dst_airport: "SEA" }, { src_airport: "SEA" }],
})
```

#### `$and` y `$or`
Usa `$and` en expresiones `$or`.

Ejemplo:
```js
db.routes.find({
  $and: [
    { $or: [{ dst_airport: "SEA" }, { src_airport: "SEA" }] },
    { $or: [{ "airline.name": "American Airlines" }, { airplane: 320 }] },
  ]
})
```
</br>

## Remplazar, actualizar y borrar documentos
### Remplazar un documento

Se puede usar `replaceOne()` para remplazar documentos.
<br>Esta función usa los siguientes parámetros:

- `filter`: Query que concuerda con el documento a remplazar
- `replacement`: Nuevo documento
- `options`: Objeto que especifica opciones

Ejemplo:
```js
db.books.replaceOne(
  {
    _id: ObjectId("6282afeb441a74a98dbbec4e"),
  },
  {
    title: "Data Science Fundamentals for Python and MongoDB",
    isbn: "1484235967",
    publishedDate: new Date("2018-5-10"),
    thumbnailUrl:
      "https://m.media-amazon.com/images/I/71opmUBc2wL._AC_UY218_.jpg",
    authors: ["David Paper"],
    categories: ["Data Science"],
  }
)
```
</br>

### Acutalizar un documento usando `updateOne()`
Esta función permite un filtro, un nuevo documento y un objeto de opciones opcional.
<br><br>Los operadores que podemos usar son:

#### `$set`:
Remplaza el valor del campo por el nuevo valor.

Ejemplo:
```js
db.podcasts.updateOne(
  {
    _id: ObjectId("5e8f8f8f8f8f8f8f8f8f8f8"),
  },

  {
    $set: {
      subscribers: 98562,
    },
  }
)
```

#### `upsert`:
Crea un nuevo documento si ningun documento concuerda con el criterio.

Ejemplo: 
```js
db.podcasts.updateOne(
  { title: "The Developer Hub" },
  { $set: { topics: ["databases", "MongoDB"] } },
  { upsert: true }
)
```

#### `$push`:
Añade el nuevo valor al Array del documento.

Ejemplo:
```js
db.podcasts.updateOne(
  { _id: ObjectId("5e8f8f8f8f8f8f8f8f8f8f8") },
  { $push: { hosts: "Nic Raboy" } }
)
```
</br>

### Actualizar un documento usando `findAndModify()`
Usa `findAndModify()` para buscar y remplazar un documento. Acepta un filtro, un documento que remplazar y un objeto de opciones.

Ejemplo:
```js
db.podcasts.findAndModify({
  query: { _id: ObjectId("6261a92dfee1ff300dc80bf1") },
  update: { $inc: { subscribers: 1 } },
  new: true,
})
```
</br>

### Actualizar documentos usando `updateMany()`
Usa `updateMany()` para actualizar múltiples documentos. Acepta un filtro, un documento que remplazar y un objeto de opciones.

Ejemplo:
```js
db.books.updateMany(
  { publishedDate: { $lt: new Date("2019-01-01") } },
  { $set: { status: "LEGACY" } }
)
```
</br>

### Borrar un documento
Usa `deleteOne()` para borrar un solo documento. Acepta un filtro y un objeto de opciones.

Ejemplo:
```js
db.podcasts.deleteOne({ _id: Objectid("6282c9862acb966e76bbf20a") })
```
</br>

### Borrar múltiples documentos
Usa `deleteMany()` para borrar un solo documento. Acepta un filtro y un objeto de opciones.

Ejemplo:
```js
db.podcasts.deleteMany({category: “crime”})
```
</br>

## Modificar resultardos de Query
### Ordenar y limitar resultados de Query
#### `sort()`:
Usa para ordenar los resultados de una consulta. Requiere un objeto que especifica el campo por donde ordenar y si es ascendiente (`1`) o descendiente (`-1`)

Sintáxis:
```js
db.collection.find(<query>).sort(<sort>)
```

Ejemplo:
```js
// Devuelve información de todas las compañias de musica ordenadas alfabéticamente de la A a la Z
db.companies.find({ category_code: "music" }).sort({ name: 1 });
```

Para que los documentos sean devueltos en un orden consistente, incluye un campo con un valor único, como `_id`.

Ejemplo:
```js
// Devuelve información de todas las compañias de musica ordenadas alfabéticamente de la A a la Z
// Asegura orden constante
db.companies.find({ category_code: "music" }).sort({ name: 1, _id: 1 });
```

#### `limit()`:
Usa para especificar el máximo de documentos que se devuelven. Requiere un número máximo de documentos.

Sintáxis:
```js
db.companies.find(<query>).limit(<number>)
```

Ejemplo:
```js
// Devuelve información de 3 las compañias de musica ordenadas alfabéticamente de la Z a la A (descendiente)
// Asegura orden constante
db.companies
  .find({ category_code: "music" })
  .sort({ number_of_employees: -1, _id: 1 })
  .limit(3);
```
</br>

### Devolver información específica
Puedes usar un documento de "proyección" como segundo parámetro en el `find()` para incluir o excluir campos.

Sintáxis:
```js
db.collection.find( <query>, <projection> )
```

#### Incluir un campo:
Para incluir un campo, pon su valor a 1 en el documento de proyección.

Sintáxis:
```js
db.collection.find( <query>, { <field> : 1 })
```

Ejemplo:
```js
// Devuelve todas las inspecciones de un restaurante - Solo devuelve el NOMBRE DE NEGOCIO, el RESULTADO y el _ID
db.inspections.find(
  { sector: "Restaurant - 818" },
  { business_name: 1, result: 1 }
)
```

#### Excluir un campo
Para excluir un campo, pon su valor a 0 en el documento de proyección.

Sintáxis:
```js
db.collection.find(query, { <field> : 0, <field>: 0 })
```

Ejemplo:
```js
// Devuelve todas las inspecciones con un resultado de "Pass" o "Warning" - Excluyendo las dadas DATE y ADDRESS.ZIP
db.inspections.find(
  { result: { $in: ["Pass", "Warning"] } },
  { date: 0, "address.zip": 0 }
)
```

Aunque `_id` está incluido de forma predeterminada, se puede excluir.

Ejemplo:
```js
// Devuelve todas las inspecciones de un restaurante - Solo devuelve el NOMBRE DE NEGOCIO y el RESULTADO.
// El _ID no sale
db.inspections.find(
  { sector: "Restaurant - 818" },
  { business_name: 1, result: 1, _id: 0 }
)
```
</br>

### Contar documentos
Usa `countDocuments()` para contar los documentos que concuerdan con una Query. Requiere de un documento de query y de un documento de opciones.

Sintáxis:
```js
db.collection.countDocuments( <query>, <options> )
```

Ejemplo:
```js
// Cuenta los documentos de esa colección
db.trips.countDocuments({})
```

```js
// Cuenta los documentos de esa colección con duración mayor a 120 por "Subscriber"
db.trips.countDocuments({ tripduration: { $gt: 120 }, usertype: "Subscriber" })
```