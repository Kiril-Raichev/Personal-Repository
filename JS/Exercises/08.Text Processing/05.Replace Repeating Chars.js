function result(string) {
    let result = '';

    for(let el of string){
        if(el !== result[result.length-1]){
            result +=el;
        }
    }
    console.log(result);
}
result(
    'aaaaabbbbbcdddeeeedssaa'
)