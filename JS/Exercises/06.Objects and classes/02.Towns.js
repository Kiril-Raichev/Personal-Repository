function result(array) {

    for (let table of array) {
        let [town, lat, long] = table.split(" | ");

        let currentCity = {
            town,//samo kato polzvash liniqta ot gore
            latitude:Number(lat).toFixed(2),
            longitude:Number(long).toFixed(2)
        }
        console.log(currentCity)
    }
}
result([
    'Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625'
]);