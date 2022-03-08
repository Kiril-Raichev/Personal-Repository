function result(index) {
    let username = index[0];
    let result = username.split('').reverse().join('');
    let block = 0;
    for (i = 1; i < index.length; i++) {
        let password = index[i];
        if (password === result) {
            console.log(`User ${username} logged in.`);
        } else {
            if (block === 3) {
                console.log(`User ${username} blocked!`)
            } else {
                console.log("Incorrect password. Try again.");
                block++;
            }

        }
    }
}
result(['Acer',
    'login',
    'go'])