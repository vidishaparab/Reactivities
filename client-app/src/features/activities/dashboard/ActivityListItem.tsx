import React from 'react'
import { Item, Button, Segment, Icon } from 'semantic-ui-react'
import { IActivity } from '../../../app/models/activity';
import { Link } from 'react-router-dom'

const ActivityListItem:React.FC<{activity:IActivity}> = ({activity}) => {
    return (
        <Segment.Group>
            <Segment>
                <Item.Group>
                <Item>
                <Item.Image size='tiny' circular src='/assets/user.png'></Item.Image>
            <Item.Content verticalAlign='middle'>
            <Item.Header>{activity.title}</Item.Header>
            <Item.Description>
                Hosted by Bob
            </Item.Description>

            </Item.Content>
    </Item>
                </Item.Group>
            
            </Segment>
            <Segment>
                <Icon name='clock'/>{activity.date}
                <Icon name='marker'/> { activity.venue}, {activity.city}
            </Segment>
            <Segment secondary>
                Attendees will go here
            </Segment>
            <Segment clearing>
    <span>{activity.description}</span>
    <Button floated='right' color= "instagram"  as={Link} to ={`/activities/${activity.id}`}>View Activity</Button>
            </Segment>
        </Segment.Group>
       
    )
}

export default ActivityListItem;
