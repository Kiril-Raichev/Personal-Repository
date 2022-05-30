function result(arr) {
    let newArr = [];
    for (let i = 0; i < arr.length; i++) {
        let count = 0;
        for (let j = 1; j < arr.length; j++) {
            if (arr[i] > arr[j]) {
                count++;
            }
        }
        let diff = arr.length - (i + 1);
        if(diff === count){
            newArr.push(arr[i]);
        }
    }
    console.log(newArr.join(' '));
}
result([13, 24, 3, 19, 15, 17]);