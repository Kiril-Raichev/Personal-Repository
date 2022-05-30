function result(array) {
    let countries = {};

    for(let el of array){
        let current = el.split(" > ");
        let country = current[0];
        let city = current[1];
        let cost = +current[2];

        if(!countries.hasOwnProperty(country)){
            countries[country] = {};
        }
        if(!countries[country].hasOwnProperty(city)){
            countries[country][city] = cost;
        }
        if(countries[country][city] > cost){
            countries[country][city] = cost;
        }
    }
    let keys = Object.keys(countries); //izvajda countries 
    keys.sort((a,b)=> a.localeCompare(b)); //sortira countries

    for(let el of keys){
        let sortedCities = Object.entries(countries[el]); //object entries go pravi masiv ot masivi
        sortedCities.sort((a,b) => a[1] - b[1]);   
        let result = [];
        for(let city of sortedCities){
            result.push(city.join(" -> "));
        } 
        console.log(`${el} -> ${result.join(" ")}`);
    }

}
result(
    [
        "Bulgaria > Sofia > 500",
        "Bulgaria > Sopot > 800",
        "France > Paris > 2000",
        "Albania > Tirana > 1000",
        "Bulgaria > Sofia > 200"
        ]
        
)