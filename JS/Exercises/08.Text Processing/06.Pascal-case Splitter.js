function result(string) {

    string = string.split("");
    let words = [];

    string.forEach(el => {
        if(el.charCodeAt(0) >=65 && el.charCodeAt(0) <= 90){
            words.push(el); //slagash glavni bukvi kato elementi  v masic
        }else if(el.charCodeAt(0)>=97 && el.charCodeAt(0)<= 122){
            words[words.length-1] +=el;// slagash malka bukva kum elementa v masiva
        }
    });
    console.log(words.join(", "));
}
result(
    'SplitMeIfYouCanHaHaYouCantOrYouCan'
)