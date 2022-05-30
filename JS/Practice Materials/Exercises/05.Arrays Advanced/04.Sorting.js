function test(input) {
    let final = [];
    let size = input.length / 2;
    for (i = 0; i < size; i++) {
        let newArr = input.sort((a, b) => {
            return a - b;
        });
        if (input.length == 1) {
            final.push(input[0]);
        } else {
            let smallest = newArr.shift();
            let biggest = newArr.pop();
            final.push(biggest);
            final.push(smallest);
        }
    }
    console.log(final.join(' '));
}
test(
    [34, 2, 32, 45, 69, 6, 32, 7, 19, 47, 2]
);
 //alternativa
function test2(input) {
    let final = [];
    let sortedArr  = input.sort((a,b)=>{
        return a - b;
    });
    while(sortedArr.length!==0){
        let bigNum = sortedArr.pop();
        let smallNum = sortedArr.shift();

        final.push(bigNum);
        final.push(smallNum)
    }
    console.log(final.join(' '));
}
test2(
    [34, 2, 32, 45, 69, 6, 32, 7, 19, 47, 2]
);