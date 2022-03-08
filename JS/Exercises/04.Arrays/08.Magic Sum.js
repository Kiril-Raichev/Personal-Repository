function result(arr, sum) {
    for (let i = 0;i<arr.length;i++){
        let newArr = [];
        for(j = i + 1;j<arr.length;j++){
            if(arr[i] + arr[j] == sum){
                newArr.push(arr[i]);
                newArr.push(arr[j]);
                console.log(newArr.join(' '));
            }
        }
    }
}
result([1,7,6,2,19,13],
        8);