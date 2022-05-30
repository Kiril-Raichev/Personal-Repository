function result(number) {
    for (i = 1; i <= 10; i++) {
        let result = i*number;
        console.log(`${number} X ${i} = ${result}`);
    }
}
result(5)