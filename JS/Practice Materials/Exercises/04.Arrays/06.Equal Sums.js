function result(arr) {
    let count3 = 0;
    for (let i = 0; i < arr.length; i++) {
        let count1 = 0;
        let count2 = 0;
        if(arr.length == 1){
            console.log(0);
        }
        if (i == 0 || i == arr.length - 1) {
            count1 += 0;
            count2 += 0;
            count3++;
        } else {
            for (let j = 0; j < i; j++) {
                count1 += arr[j];
            }
            let h = i + 1;
            for (h; h < arr.length; h++) {
                count2 += arr[h];
            }
            if (count1 === count2) {
                console.log(i);
            } else {
                count3++;
            }
        }
    }
    if(count3 == arr.length && count3 != 1){
        console.log('no');
    }
}
result([1,2,3,3]);