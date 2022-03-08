function result(array) {
    let wordsSearch = array.shift().split(" ");

    let myWords = {};

    for(let el of wordsSearch){
        myWords[el] = 0;
    }
    for(let word of array){
        if(myWords.hasOwnProperty(word)){
            myWords[word]++;
        }
    }
    let sort = Object.entries(myWords).sort((a,b)=> b[1] - a[1] ); // vrushta 2ta massiva ot duma i broi

    sort.forEach((el) =>{
        console.log(`${el[0]} - ${el[1]}`);
    });
}
result([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurances', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    )