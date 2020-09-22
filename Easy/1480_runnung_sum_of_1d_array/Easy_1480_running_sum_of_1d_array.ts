function runningSum(nums: number[]): number[] {
    let curr = 0;
    return nums.map(num => curr += num);
};