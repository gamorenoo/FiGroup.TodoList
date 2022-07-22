import React, { useState } from 'react';
import AppBar from '@material-ui/core/AppBar';
import Box from '@material-ui/core/Box';
import Toolbar from '@material-ui/core/Toolbar';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Snackbar from '@material-ui/core/Snackbar';
import { saveTodo } from '../../services/todo.api.services'

export default function ButtonAppBar() {
	const [open, setOpen] = useState(false);
	const [openSnackbar, setOpenSnackbar] = useState(false);

	const handleClickOpen = () => {
		setOpen(true);
	};

	const handleClose = () => {
		setOpen(false);
	};
	
	const handleCloseSnackbar = () => {
		setOpenSnackbar(false);
	};
	
	
	const [todo, setTodo] = useState({
		id: null,
        title: '',
        detail: '',
		status: false
    })
	
	const handleInputChange = (event) => {
        // console.log(event.target.name)
        // console.log(event.target.value)
        setTodo({
            ...todo,
            [event.target.name] : event.target.value
        })
    }
	  
	const handleCloseTodoSave = () => {
		if(todo.title == '' || todo.detail == ''){
			setOpenSnackbar(true);
			return false;
		}
		saveTodo(todo);
		setOpen(false);
		window.location.reload(true)
	}
	
	const action = (
    <div>
      <Button color="secondary" size="small" onClick={handleCloseSnackbar}>
        Cerrar
      </Button>
    </div>
  );
  
	return (
		<div>
			<Box sx={{ flexGrow: 1 }}>
			  <AppBar position="static">
				<Toolbar>
				  <Button onClick={handleClickOpen} variant="outlined" color="inherit">Crear Tarea</Button>
				</Toolbar>
			  </AppBar>
			</Box>
			<Dialog open={open} onClose={handleClose}>
				<DialogTitle>Crear Tarea</DialogTitle>
				<DialogContent>
				  <DialogContentText>
				  <TextField
					autoFocus
					margin="dense"
					id="title"
					name="title"
					label="Título"
					type="text"
					fullWidth
					variant="standard"
					onChange={handleInputChange}
				  />
				  <TextField
					autoFocus
					margin="dense"
					id="detail"
					name="detail"
					label="Detalle tarea"
					type="text"
					fullWidth
					variant="standard"
					onChange={handleInputChange}
				  />
				  </DialogContentText>
				</DialogContent>
				<DialogActions>
				  <Button onClick={handleClose}variant="outlined" color="default">Cancel</Button>
				  <Button onClick={handleCloseTodoSave} variant="contained" color="primary">Guardar</Button>
				</DialogActions>
			</Dialog>
			
			<Snackbar open={openSnackbar} autoHideDuration={6000} onClose={handleCloseSnackbar} message="Debe ingresar el título y el detalle de la tarea" action={action}>
			</Snackbar>
			
		</div>
	);
}