function result(startNum, endNum) {
    let sum = 0;
    let numbers= '';
    for (let index = startNum; index < endNum+1; index++){
        numbers += index.toString() + " ";
        sum +=index;
    }
    console.log(numbers);
    console.log(`Sum: ${sum}`)
}
result(5,10)