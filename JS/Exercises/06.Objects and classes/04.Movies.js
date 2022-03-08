function result(array) {
    let movies = [];

    for(let line of array){
        if(line.includes("addMovie")){
            let name = line.split("addMovie ")[1]; 
            // maha add movie i izbita elementa 
            //na 1vi index zashtoto na nulev ima space
            movies.push({name:name})
        }else if(line.includes("directedBy")){
            let [name,director] = line.split(" directedBy ");

            let movie = movies.find((movieObj => movieObj.name === name));

            if(movie){
                movie.director = director;
            }
        }else if(line.includes("onDate")){
            let [name,date] = line.split(" onDate ");

            let movie = movies.find((movieObj => movieObj.name === name));

            if(movie){
                movie.date = date;
            }
        }
    }
        movies.forEach(movie=>{
            if(movie.name && movie.director && movie.date){
                console.log(JSON.stringify(movie));//strigify slaga  tova ->" "
            }
        })
}
result([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]
    )