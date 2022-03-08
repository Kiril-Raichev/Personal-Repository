function result(word, text) {
    let sentence = text.toLowerCase();
    let wordToLower = word.toLowerCase();
    let sentenceAsArray = sentence.split(" ");

    if(sentenceAsArray.includes(wordToLower)){
        console.log(wordToLower);
    }else{
        console.log(`${wordToLower} not found!`)
    }
}
result(
    'javascript',
    'JavaScript is the best programming language'

)