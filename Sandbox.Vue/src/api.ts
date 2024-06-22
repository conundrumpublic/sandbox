export async function allUsers(): Promise<User[]> {
    return await fetch("http://localhost:5106/User/GetAll")
        .then(r => r.json());
}