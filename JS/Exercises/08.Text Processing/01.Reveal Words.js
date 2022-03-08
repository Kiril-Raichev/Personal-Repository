function result(words,sentence) {
    
    let wordsArray = words.split(", ");

    for(let word of wordsArray){
        let template = "*".repeat(word.length);
        sentence = sentence.replace(template, word);
    }
    console.log(sentence);
}
result(
    'great, learning',
    'softuni is ***** place for ******** new programming languages'
    
)