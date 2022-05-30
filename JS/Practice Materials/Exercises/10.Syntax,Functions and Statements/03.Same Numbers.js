function result(number) {
    let test = true;
    let buffer = number % 10;
    let sum = 0;

    while (number > 0){
        let current = number % 10 ;
        number = Math.floor(number/10);
        if (current!=buffer){
            test = false;
        }
        sum+=current;
    }
    console.log(test)
    console.log(sum)
    
}
result(1234

    )