import React, { useState } from 'react';
import Editor from 'react-simple-code-editor';
import { highlight, languages } from 'prismjs/components/prism-core';
import 'prismjs/components/prism-clike';
import 'prismjs/components/prism-csharp';
import { linguagens } from './staticData/linguagensDisponiveis';

function App() {
	const [linguagem, setLinguagem] = useState('csharp');
	const [code, setCode] = useState(linguagens[0].template);
	const [resultados, setResultados] = useState([]);
	const [entradas, setEntradas] = useState([]);
	const [inputEntrada, setInputEntrada] = useState('');

	return (
		<div>
			<select onChange={({ target }) => {
				setLinguagem(target.value);
				setCode(linguagens.filter(lang => lang.id === target.value)[0].template);
			}} value={linguagem}>
				{linguagens.map(lang => {
					return (<option key={lang.id} value={lang.id}>{lang.display}</option>);
				})}
			</select>
			<Editor
				value={code}
				onValueChange={code => setCode(code)}
				highlight={code => highlight(code, languages.cs, '')}
				tabSize={4}
				padding={10}
				style={{
					fontFamily: '"Fira code", "Fira Mono", monospace',
					fontSize: 12,
					height: 300,
					backgroundColor: '#424242',
					color: 'white'
				}}
			/>
			<input type="text" onChange={({ target }) => setInputEntrada(target.value)} value={inputEntrada} />
			<button onClick={() => {
				setEntradas([...entradas, inputEntrada]);
				setInputEntrada('');
			}}>Adicionar</button>
			<br />
			<span>Entradas</span>
			<ul>
				{
					entradas.map((entrada, i) => {
						return <li key={i}>{entrada}</li>
					})
				}
			</ul>
			<br />
			<span>Saídas</span>
			<ul>
				{
					resultados.map((res, i) => {
						return (<li key={i}>{res}</li>)
					})
				}
			</ul>

			<button onClick={() => {
				compile(code, linguagem, entradas)
					.then(retorno => {
						setResultados([...resultados, retorno.output]);
					});
			}}>Compilar</button>
		</div>
	);
}

async function compile(code, linguagem, entradas) {
	const formData = new FormData();
	formData.append("code", code);
	formData.append("inputs", entradas);
	const response = await fetch(`https://localhost:44351/api/compiler/${linguagem}`, { method: 'POST', body: formData });
	const payload = await response.json();
	console.log(payload);
	return payload;
}

export default App;
