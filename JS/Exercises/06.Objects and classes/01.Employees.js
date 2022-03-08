function result(array){

    for (let personalName of array){
        let eachPerson = {
            name:personalName,
            number:personalName.length
        }
        console.log(`Person: ${eachPerson.name} -- Number: ${eachPerson.number}`)
    }
}
result([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    )