<template>
    <div>
    <Titulo text="Professores" :btnVoltar="true"/>
    <table border="1px">
      <thead>
        <th>Cód.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td class="colPequena" >{{professor.id}}</td>
          <router-link 
            :to="`/alunos/${professor.id}`"
            tag="td" 
            style="cursor:pointer">
            {{professor.nome}} {{professor.sobrenome}}
          </router-link>
          <td class="colPequena" > 
            {{professor.qtdAlunos}}
          </td>
        </tr>
      </tbody>
      <tfoot v-if="!professores.length">
        <tr>
          <td colspan="3" style="text-align: center" >
            <h5>Nenhum professor encontrado</h5>
          </td>
        </tr>
      </tfoot>
     </table>
    </div>
</template>

<script>
    import Titulo from '../_share/Titulo'
    export default {
        components: {
            Titulo
        },
        props: {},
        data() {
            return {
                professores: [],
                alunos: []
            }
        },
        created() {
          this.$http.get('http://localhost:5000/api/aluno')
          .then(res => res.json())
          .then(alunos => {
              this.alunos = alunos;
              this.carregarProfessores();
            }
          )
        },
        methods: {
          pegarQuantidadeDeAlunoPorProfessor(){
            this.professores.forEach((professor,index)=>{
              professor = {
                id: professor.id,
                nome: professor.nome,
                sobrenome: professor.sobrenome,
                qtdAlunos: this.alunos.filter(aluno => aluno.professor.id === professor.id).length
              }
              this.professores[index] = professor;
            });
          },
          carregarProfessores(){
              this.$http.get('http://localhost:5000/api/professor')
              .then( res => res.json())
              .then(professores => {
                this.professores = professores;
                this.pegarQuantidadeDeAlunoPorProfessor();
              }
            );
          }
        },
    }
</script>

<style scoped>
  .colPequena{
    width:20%; 
    text-align: center;
  }
</style>