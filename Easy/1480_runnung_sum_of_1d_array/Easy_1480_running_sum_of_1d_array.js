function runningSum(nums) {
    let curr = 0;
    return nums.map(num => curr += num);
};