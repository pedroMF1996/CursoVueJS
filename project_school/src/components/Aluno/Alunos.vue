<template>
  <div>
    <Titulo text="Aluno"/>
    <div>
      <input 
        type="text" 
        placeholder="Nome do Aluno"
        v-model="nome"
        @keyup.enter="addAluno()"/>
      <button class="btn btn_input" @click="addAluno()">
        Adicionar
      </button>
    </div>
    <table border="1px">
      <thead>
        <th>Mat</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <td>{{aluno.nome}} {{aluno.sobrenome}}</td>
          <td>
            <button class="btn btn_danger" @click="removerAluno(aluno.id)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="!alunos.length">
        Nenhum aluno encontrado
      </tfoot>
     </table>
  </div>
</template>

<script>

import Titulo from '../_share/Titulo';

export default {
  name: 'Alunos',
  components: {
    Titulo
  },
  props: {
    },
  data:function() {
      return {
          titulo: 'Aluno',
          nome: '',
          alunos: [
            {id:1, nome: 'Astolfo'}, 
            {id:2, nome: 'Marcus'}, 
            {id:3, nome: 'Gariela'}]
      };
      
  },
  created() {
    this.index();
  },
  methods: {
    index(){
      this.$http.get('http://localhost:3000/alunos')
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    },
    addAluno(){
      const _aluno = {
        nome: this.nome.split(' ')[0],
        sobrenome: this.nome.split(' ')[1]
      }
      // this.alunos.push(this.nome);
      
      this.$http.post('http://localhost:3000/alunos',_aluno)
      .then(res => res.json())
      .then(aluno => {
        this.alunos.push(aluno);
        this.nome = '';
      })
    },

    removerAluno(id){
      this.$http.delete(`http://localhost:3000/alunos/${id}`)
      .then(this.index());
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  input{
    border: 0;
    padding: 20px;
    font-size: 1.3em;
    color: #687f7f;
    display: inline;
  }
  .btn_input{
    border: 0px;
    padding: 20px;
    font-size: 1.3;
    display: inline;
    background-color: rgb(116, 115, 115);
  }
  .btn_input:hover{
    padding: 20px;
    margin: 0px;
    border: 0px;
  }
</style>
