function result(arr) {
    let total =0;
    let newTotal = 0;
    for(let i =0;i<arr.length;i++){
        total +=arr[i];
        if(arr[i]%2===0){
            arr[i]+=i;
        }else{
            arr[i]-=i;
        }
        newTotal += arr[i];
    }
    console.log(arr);
    console.log(total);
    console.log(newTotal);
}
result([5,15,23,56,35])