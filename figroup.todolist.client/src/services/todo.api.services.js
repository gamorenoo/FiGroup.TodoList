import axios from 'axios'

const getTodo = async(state) => {
    const todos = await axios.get('https://localhost:44377/api/Todo');
    state(todos.data.result);
}

const deleteTodo = async(todoId) => {
    await axios.delete('https://localhost:44377/api/Todo/' + todoId);
}

const saveTodo = async(todo) => {
    await axios.post('https://localhost:44377/api/Todo/', todo);
}

export {
    getTodo,
    deleteTodo,
    saveTodo
}