function result(number, type, day) {
    let priceOne;
    let fullPrice;
    let finalPrice;
    let result;
    if (type === 'Students') {
        switch (day) {
            case 'Friday': priceOne = 8.45;

                break;
            case 'Saturday': priceOne = 9.80;

                break;
            case 'Sunday': priceOne = 10.46;

                break;
        }
        fullPrice = number * priceOne;
        if (number >= 30) {
            finalPrice = fullPrice * 0.85;
        } else {
            finalPrice = fullPrice;
        }
        result = finalPrice.toFixed(2);
    }
    else if (type === 'Business') {
        switch (day) {
            case 'Friday': priceOne = 10.90;

                break;
            case 'Saturday': priceOne = 15.60;

                break;
            case 'Sunday': priceOne = 16;

                break;
        }
        fullPrice = number * priceOne;
        if (number >= 100) {
            finalPrice = fullPrice - (fullPrice * 10);
        } else {
            finalPrice = fullPrice;
        }
        result = finalPrice.toFixed(2);
    }
    else if (type === 'Regular') {
        switch (day) {
            case 'Friday': priceOne = 15;

                break;
            case 'Saturday': priceOne = 20;

                break;
            case 'Sunday': priceOne = 22.50;

                break;
        }
        fullPrice = number * priceOne;
        if (number >= 10 && number <= 20) {
            finalPrice = fullPrice * 0.95;
        } else {
            finalPrice = fullPrice;
        }
        result = finalPrice.toFixed(2);
    }
    console.log(`Total price: ${result}`)

}
result(30,
    'Students',
    'Sunday')