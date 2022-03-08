function result(numbers, commands) {
    for (let command of commands) {
        let tokens = command.split(' ');
        let current = tokens[0];

        if (current === "add") {
            let index = +tokens[1];
            let element = +tokens[2];
            numbers.splice(index, 0, element);

        } else if (current === "addMany") {
            let index = +tokens[1];
            tokens.splice(0,2);
            let toAdd = tokens.map(Number);
            numbers.splice(index,0,...toAdd);

        } else if (current === "contains") {
            let result = numbers.indexOf(+tokens[1]);
            console.log(result);
        } else if (current === "remove") {
            let index = +tokens[1];
            numbers.splice(index,1);
        } else if (current === "shift") {
            let position = tokens[1];
            for(let i = 0;i < position;i++){
                let firstNumber = numbers.shift();
                numbers.push(firstNumber);
            }
        } else if (current === "sumPairs") {
            let arr =[];
            if(numbers.length %2 !== 0){
                numbers.push(0);
            }
            for(let i =0;i<numbers.length-1;i+=2){
                let sum = numbers[i] + numbers[i+1];
                arr.push(sum);
            }
            numbers = arr;
            
        } else if (current === "print") {
            console.log(`[ ${numbers.join(', ')} ]`)
        }

    }
}
result([1, 2, 4, 5, 6, 7],
    ['add 1 8', 'contains 1', 'contains 3', 'print']
);