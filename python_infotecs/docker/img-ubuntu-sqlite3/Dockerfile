FROM ubuntu:16.04

RUN apt-get update && apt-get install -y openssh-server iproute2
RUN mkdir /var/run/sshd
RUN echo 'root:pwd' | chpasswd
RUN sed -i 's/PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config

#RUN apt-get install -y sqlite3 libsqlite3-dev
RUN apt-get install -y sqlite
RUN mkdir /db
RUN /usr/bin/sqlite3 /db/test.db
#CMD /bin/bash

# SSH login fix. Otherwise user is kicked off after login
RUN sed 's@session\s*required\s*pam_loginuid.so@session optional pam_loginuid.so@g' -i /etc/pam.d/sshd

ENV NOTVISIBLE "in users profile"
RUN echo "export VISIBLE=now" >> /etc/profile

EXPOSE 22
CMD ["/usr/sbin/sshd", "-D"]