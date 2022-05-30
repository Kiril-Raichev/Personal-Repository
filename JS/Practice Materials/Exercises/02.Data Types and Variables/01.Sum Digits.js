function result(number) {
    let string = number.toString().split('');
    let result = 0;
    for(i=0;i<string.length;i++){
        result += Number(string[i]);
    }
    console.log(result);
}
result(97561);