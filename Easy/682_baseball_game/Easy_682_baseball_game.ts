var calPoints = function (ops: string[]) {
    let sum = 0;
    const arr: string[] = [];
    let newValue = 0;
    ops.forEach(operation => {
        switch (operation) {
            case "+":
                newValue = +arr[arr.length - 1] + +arr[arr.length - 2];
                break;
            case "D":
                newValue = +arr[arr.length - 1] * 2;
                break;
            case "C":
                newValue = -Number(arr.pop());
                break;
            default:
                newValue = +operation;
                break;
        }
        if (operation !== "C")
            arr.push(newValue.toString());
        sum += newValue;
    });
    return sum;
};