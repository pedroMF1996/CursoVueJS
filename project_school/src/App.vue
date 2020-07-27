<template>
  <div id="app">
    <Alunos/>
  </div>
</template>

<script>
import Alunos from './components/Aluno/Alunos.vue'

export default {
  name: 'App',
  components: {
    Alunos
  }
}
</script>

<style>
body{
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}
body, html {
  margin: 0;
  height: 100%;
}

.btn{
  padding: 10px 20px;
  border: 1px solid black;
  cursor: pointer;
  color: white;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
}

.btn_danger{
  background-color: #fa4430;
}

.btn:hover{
  text-shadow: 1px 1px 1px black;
  border-bottom: 1px solid black;
  margin-top: 3px;
}
table {
  margin: 0px;
  padding: 0px;
  list-style: none;
  width: 100%;
}

table thead th {
  background-color: rgb(184,208,216) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}

table tr td{
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}

.colPequena{
  width: 5%;
}
</style>
