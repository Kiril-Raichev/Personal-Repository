function result(arr1,arr2) {
    arr3=[];
    for(let i = 0;i<arr1.length;i++){
        if (i%2===0){
            let curr = Number(arr1[i]) + Number(arr2[i]);
            let curr1 = curr.toString();
            arr3.push(curr1);
        }else{
            let curr = arr1[i] + arr2[i];
            arr3.push(curr);
        }
    }
    let newArr = arr3.join(' - ');
    console.log(newArr);
}
result(['5','15','23','56','35'],
        ['17','22','87','36','11'])