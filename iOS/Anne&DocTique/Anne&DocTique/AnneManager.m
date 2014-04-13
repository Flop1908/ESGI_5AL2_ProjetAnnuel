//
//  AnneManager.m
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "AnneManager.h"
#import "GroupBuilder.h"
#import "AnneCommunicator.h"

@implementation AnneManager
- (void)fetchGroupsAtCoordinate:(CLLocationCoordinate2D)coordinate
{
    [self.communicator searchGroupsAtCoordinate:coordinate];
}

#pragma mark - AnneCommunicatorDelegate

- (void)receivedGroupsJSON:(NSData *)objectNotation
{
    NSError *error = nil;
    NSArray *groups = [GroupBuilder groupsFromJSON:objectNotation error:&error];
    
    if (error != nil) {
        [self.delegate fetchingGroupsFailedWithError:error];
        
    } else {
        [self.delegate didReceiveGroups:groups];
    }
}

- (void)fetchingGroupsFailedWithError:(NSError *)error
{
    [self.delegate fetchingGroupsFailedWithError:error];
}
@end
