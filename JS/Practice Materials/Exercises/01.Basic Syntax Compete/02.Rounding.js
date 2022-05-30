function result(number, precision) {
    if(precision >15){
        precision = 15;
    }
    let result = number.toFixed(precision);
    let final = parseFloat(result);
    console.log(final);
}
result(10.5, 3)

