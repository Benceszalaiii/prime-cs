
fn main() {
    println!("List prime numbers till: ");
    let mut n = String::new();
    std::io::stdin()
        .read_line(&mut n)
        .expect("failed to read input.");
    let n: usize = n.trim().parse().expect("invalid input");

    let start = std::time::Instant::now();
    let mut primes: Vec<bool> = vec![true;n];
    primes[0] = false;
    primes[1] = false;
    let last_index = f32::sqrt(n.clone() as f32).floor() as usize;
    let mut i: usize = 2;
    while i < last_index{
        if primes[i]{
            let mut j: usize = i*2;
            while j < n{
                primes[j] = false;
                j += i;
            }
        }
        i+= 1;
    }
    let count = primes.iter().filter(|c| **c).collect::<Vec<&bool>>().len();
    let end = std::time::Instant::now();
    let processed = end.duration_since(start).as_millis();
    println!("{:?}", primes.iter().enumerate().filter(|&(_, &v)| v).map(|(index, _)| index).collect::<Vec<usize>>());
    println!("Number of primes: {}", count);
    println!("Elapsed time: {}ms", processed);
    println!("\n\nPress ENTER to exit...");
    std::io::stdin().read_line(&mut String::new()).unwrap();
}
