import React from 'react';
import Todo from './components/Todo'
import TodoCard from './components/TodoCard/TodoCard'
import AppBar from './components/AppBar/AppBar'

function App() {

    return ( <div>
			<AppBar/>
			<TodoCard/>
		</div>
    );
}

export default App;