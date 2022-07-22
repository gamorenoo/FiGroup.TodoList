import React, { useEffect, useState } from 'react';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import './TodoCards.css'
import { getTodo, deleteTodo, saveTodo } from '../../services/todo.api.services'

// export function TodoCard ({ todos }) { 

const TodoCard = () => {

    const [todos, setTodos] = useState([])
    useEffect(() => {
        getTodo(setTodos)
    },[])
	
	const handleTodoDelte = (todoId) => {
		deleteTodo(todoId)
		window.location.reload(true)
	}
	
	const handleTodoSave = (todo, status) => {
		todo.status = status
		saveTodo(todo)
		window.location.reload(true)
	}

    return ( 
		<>
        {todos == null ? ('No hay tareas'):(
			todos.map(todo => (
				<Card key={todo.id} className="root">
					<CardContent>
						<Typography className="title" color="textPrimary" gutterBottom>
							{todo.title}
						</Typography>
						<Typography variant="h5" component="h2"></Typography>
						<Typography className="pos" color="textSecondary">
							Detalle
						</Typography>
						<Typography variant="body2" component="p">
							{todo.detail}
						</Typography>
					</CardContent>
					<CardActions>
						{todo.status ? (
							<Button onClick={() => {handleTodoSave(todo,false);}} size="small" variant="outlined" color="default">Tarea incompleta</Button>
						):(
							<Button onClick={() => {handleTodoSave(todo,true);}} size="small" variant="contained" color="primary">Completar tarea</Button>
						)}
						
						<Button size="small" onClick={() => {handleTodoDelte(todo.id);}} variant="outlined">X</Button>
					</CardActions>
				</Card>
			))
		)} 
		</>
    )
}

export default TodoCard