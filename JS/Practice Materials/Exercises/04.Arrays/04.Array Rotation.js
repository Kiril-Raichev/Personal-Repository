function result(arr, rot) {
    for(let i = 0; i < rot;i++){
        let number = arr.shift();
        arr.push(number);
    }
    console.log(arr)
}
result([51, 47, 32, 61, 21], 2);