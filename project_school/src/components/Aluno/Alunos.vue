<template>
  <div>
    <Titulo :text="prof_id !== undefined ? 'Professor: ' + professor.nome : 'Todos os alunos'" :btnVoltar="true"/>
    <div v-if="prof_id !== undefined">
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
          <td class="colPequena">{{aluno.id}}</td>
          <router-link 
            :to="`/aluno/update/${aluno.id}`" 
            tag="td" 
            style="cursor:pointer">
            {{aluno.nome}} {{aluno.sobrenome}}
          </router-link>
          <td class="colPequena">
            <button class="btn btn_danger" @click="removerAluno(aluno.id)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="!alunos.length">
        <tr>
          <td colspan="3" style="text-align: center" >
            <h5>Nenhum aluno encontrado</h5>
          </td>
        </tr>
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
          alunos: [],
          prof_id: this.$route.params.prof_id,
          professor: {}
      };
      
  },
  created() {
    if(this.prof_id){
      this.carregarProfessores(this.prof_id);
      this.carregaAlunosDoProfessor(this.prof_id);
    }
    else{
      this.index();
    }
  },
  methods: {
    index(){
      this.$http.get('http://localhost:5000/api/aluno')
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    },

    carregaAlunosDoProfessor(id){
      this.$http.get('http://localhost:5000/api/aluno/ByProfessor/' + id)
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    },

    addAluno(){
      let _aluno = {
        nome: this.nome.split(' ')[0],
        sobrenome: this.nome.split(' ')[1],
        dataNasc: "",
        professorid: this.professor.id
      };
      
      this.$http.post('http://localhost:5000/api/aluno',_aluno)
      .then(res => res.json())
      .then(aluno => {
        this.alunos.push(aluno);
        this.nome = '';
      });
    },

    removerAluno(id){
      this.$http.delete(`http://localhost:5000/api/aluno/${id}`)
      .then(this.index());
    },

    carregarProfessores(id){
      this.$http.get('http://localhost:5000/api/professor/'+id)
      .then( res => res.json())
      .then(professor => {
        this.professor = professor;
      }
      );
      console.log(this.professor);
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
    width: calc(100% - 195px);
  }
  .btn_input{
    border: 0px;
    padding: 20px;
    width: 150px;
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
