<template>
  <div id="app">
    <Nav/>
    <div class="margemPrincipal">
      <router-view :key="$route.fullPath">
      </router-view>
    </div>
  </div>
</template>

<script>
import Nav from './components/_nav/Nav'

export default {
  name: 'App',
  components: {
    Nav,
  }
}
</script>

<style>
#app{
  width: 100%;
}
.margemPrincipal{
  width: 50%;
  margin: auto;
}
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
  font-size: 1.5em;
  border-radius: 5px;
  border-bottom: 3px solid black;
}

.btn_danger{
  background-color: #fa4430;
  font-size: 0.8em !important;
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
  text-align: right;
  background-color: rgb(125, 217, 245);
  font-weight: bold;
}
</style>
